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
  
  let {network_statistics, language} = $props();
  Chart.defaults.color = '#334155';
  let canvas;
  let chart;
  let datasetsOptions = {
    fill: true,
    pointBorderWidth: 1,
    pointHoverRadius: 0,
    pointHoverBorderWidth: 0,
    pointRadius: 0,
    pointHitRadius: 0,
    borderWidth: 0.5,
  };
  let options = {
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
          font: {
            family: 'Roboto',
          },
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
            let type = language.network_statistics.bit;
            let divider = 1;
            
            if (value >= 1_000) {
              type = language.network_statistics.kbit;
              divider = 1_000;
            }
            if (value >= 1_000_000) {
              type = language.network_statistics.mbit;
              divider = 1_000_000;
            }
            if (value >= 1_000_000_000) {
              type = language.network_statistics.gbit;
              divider = 1_000_000_000;
            }
            if (value >= 1_000_000_000_000) {
              type = language.network_statistics.tbit;
              divider = 1_000_000_000_000;
            }
            
            if (context.parsed.y !== null) {
              label += Math.floor(value / divider) + ' ' + type + '/' + language.network_statistics.second;
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
          font: {
            family: 'Roboto',
          },
          maxRotation: 0,
          stepSize: 60
        },
        type: 'time',
        time: {
          unit: 'minute',
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
          font: {
            family: 'Roboto',
          },
          callback: function (value, index, ticks) {
            
            let type = language.network_statistics.bit;
            let divider = 1;
            
            if (value >= 1_000) {
              type = language.network_statistics.kbit;
              divider = 1_000;
            }
            if (value >= 1_000_000) {
              type = language.network_statistics.mbit;
              divider = 1_000_000;
            }
            if (value >= 1_000_000_000) {
              type = language.network_statistics.gbit;
              divider = 1_000_000_000;
            }
            if (value >= 1_000_000_000_000) {
              type = language.network_statistics.tbit;
              divider = 1_000_000_000_000;
            }
            
            return value / divider + ' ' + type + '/' + language.network_statistics.second;
          }
        }
      },
    },
  };
  
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
                label: language.network_statistics.in,
                backgroundColor: 'rgba(22,163,74,0.3)',
                borderColor: '#16a34a',
                data: incoming,
                ...datasetsOptions,
              },
              {
                label: language.network_statistics.out,
                backgroundColor: 'rgba(2,132,199,0.3)',
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