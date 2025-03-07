<script>
  import 'chartjs-adapter-luxon';
  import {
    Chart,
    Tooltip,
    Legend,
    LineElement,
    LinearScale,
    PointElement,
    TimeScale,
    LineController,
    Filler
  } from 'chart.js';
  import {onMount} from "svelte";
  
  Chart.register(
      Tooltip,
      Legend,
      LineElement,
      LinearScale,
      PointElement,
      TimeScale,
      LineController,
      Filler
  );
  
  let {network_statistics, language, light, current_time} = $props();
  Chart.defaults.color = light ? '#d1d5db' : '#334155';
  let canvas;
  let chart;
  let unit = $derived.by(() => {
    if (current_time === "year") {
      return "month";
    }
    if (current_time === "month") {
      return "day";
    }
    return "minute";
  })
  let datasetsOptions = {
    fill: true,
    pointBorderWidth: 1,
    pointHoverRadius: 0,
    pointHoverBorderWidth: 0,
    pointRadius: 0,
    pointHitRadius: 0,
    borderWidth: 0.5,
  };
  let options = $derived({
    animations: false,
    parsing: true,
    interaction: {
      mode: 'nearest',
      axis: 'x',
      intersect: false,
    },
    plugins: {
      legend: {
        labels: {
          // font: {
          //   family: 'Roboto',
          // },
        },
        align: 'end',
        onClick: () => {
        }
      },
      tooltip: {
        callbacks: {
          label: function (context) {
            let label = context.dataset.label || '';
            
            if (label) {
              label += ': ';
            }
            
            let index = context.dataIndex;
            let value = network_statistics.result[index][context.datasetIndex + 1];
            let type = language.bit;
            let divider = 1;
            
            if (value >= 1_000) {
              type = language.kbit;
              divider = 1_000;
            }
            if (value >= 1_000_000) {
              type = language.mbit;
              divider = 1_000_000;
            }
            if (value >= 1_000_000_000) {
              type = language.gbit;
              divider = 1_000_000_000;
            }
            if (value >= 1_000_000_000_000) {
              type = language.tbit;
              divider = 1_000_000_000_000;
            }
            
            if (context.parsed.y !== null) {
              label += Math.floor(value / divider) + ' ' + type + '/' + language.second;
            }
            
            return label;
          }
        }
      }
    },
    scales: {
      x: {
        border: {
          display: true,
          color: '#cbd5e1'
        },
        grid: {
          display: false,
          drawOnChartArea: false,
          drawTicks: true,
        },
        ticks: {
          // font: {
          //   family: 'Roboto',
          // },
          // maxRotation: 0,
          // stepSize: 60
        },
        type: 'time',
        time: {
          unit: unit,
        },
        adapters: {
          date: {
            locale: navigator.language
          }
        }
      },
      y: {
        adapters: {
          date: {
            locale: navigator.language
          }
        },
        border: {
          display: true,
          color: '#cbd5e1'
        },
        grid: {
          display: false,
          drawOnChartArea: false,
          drawTicks: true,
        },
        ticks: {
          // font: {
          //   family: 'Roboto',
          // },
          callback: function (value, index, ticks) {
            
            let type = language.bit;
            let divider = 1;
            
            if (value >= 1_000) {
              type = language.kbit;
              divider = 1_000;
            }
            if (value >= 1_000_000) {
              type = language.mbit;
              divider = 1_000_000;
            }
            if (value >= 1_000_000_000) {
              type = language.gbit;
              divider = 1_000_000_000;
            }
            if (value >= 1_000_000_000_000) {
              type = language.tbit;
              divider = 1_000_000_000_000;
            }
            
            return value / divider + ' ' + type + '/' + language.second;
          }
        }
      },
    },
  });
  
  $effect(() => {
    if (chart) {
      chart.destroy();
    }
    let labels = [];
    let incoming = [];
    let outgoing = [];
    
    for (let i = 0; i < network_statistics.item_count; i++) {
      labels.push(network_statistics.result[i][0]);
      incoming.push(network_statistics.result[i][1]);
      outgoing.push(network_statistics.result[i][2]);
    }
    
    chart = new Chart(
        canvas,
        {
          type: 'line',
          data: {
            labels: labels,
            datasets: [
              {
                label: language.in,
                backgroundColor: light ? 'rgba(34,197,94,0.3)' : 'rgba(22,163,74,0.3)',
                borderColor: '#16a34a',
                data: incoming,
                ...datasetsOptions,
              },
              {
                label: language.out,
                backgroundColor: light ? 'rgba(59,130,246,0.3)' : 'rgba(2,132,199,0.3)',
                borderColor: '#0284c7',
                data: outgoing,
                ...datasetsOptions
              },
            ]
          },
          options: options,
          plugins: [
            {
              id: 'verticalLiner',
              afterInit: (chart, args, opts) => {
                chart.verticalLiner = {}
              },
              afterEvent: (chart, args, options) => {
                const {inChartArea} = args
                chart.verticalLiner = {draw: inChartArea}
              },
              beforeTooltipDraw: (chart, args, options) => {
                const {draw} = chart.verticalLiner
                if (!draw) return;
                
                const {ctx} = chart
                const {top, bottom} = chart.chartArea
                const {tooltip} = args
                const x = tooltip?.caretX
                if (!x) return;
                
                ctx.save()
                
                ctx.beginPath()
                
                ctx.moveTo(x, top)
                ctx.lineTo(x, bottom)
                
                ctx.lineWidth = 1;
                ctx.strokeStyle = 'rgba(37,99,235,0.8)';
                ctx.stroke()
                
                ctx.restore()
              }
            }
          ]
        },
    );
  })
</script>

<canvas bind:this={canvas}></canvas>