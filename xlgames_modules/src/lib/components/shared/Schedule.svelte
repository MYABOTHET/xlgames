<script>
  import {onMount} from "svelte";
  import {
    CategoryScale,
    Chart,
    Filler,
    LinearScale,
    LineController,
    LineElement,
    PointElement,
    Tooltip
  } from "chart.js";

  let {points, ...props} = $props();

  let canvas;
  let datasetsOptions = {
    fill: true,
    pointBorderWidth: 1,
    pointHoverRadius: 0,
    pointHoverBorderWidth: 1,
    pointRadius: 0,
    pointHitRadius: 1,
    borderWidth: 1,
    borderDash: [1, 1],
  };
  let options = {
    plugins: {
      tooltip: {
        callbacks: {
          label: function (context) {
            let label = context.dataset.label || '';

            if (label) {
              label += ': ';
            }

            let index = context.dataIndex;
            let value = 0;
            if (context.datasetIndex === 0)
              value = points[index].in;
            else
              value = points[index].out;
            let type = language.b;
            let divider = 1;

            if (value >= 1_024) {
              type = language.kb;
              divider = 1_000;
            }
            if (value >= 1_048_576) {
              type = language.mb;
              divider = 1_000_000;
            }
            if (value >= 1_073_741_824) {
              type = language.gb;
              divider = 1_000_000_000;
            }
            if (value >= 1_099_511_627_776) {
              type = language.tb;
              divider = 1_000_000_000_000;
            }

            if (context.parsed.y !== null) {
              label += Math.floor(value / divider) + ' ' + type + '/' + language.second;
            }

            return label;
          },
          title: function (context) {
            let date = new Date(context[0].label / 1);
            let formatter = new Intl.DateTimeFormat(navigator.language, {
              month: "long",
              day: "numeric",
              hour: "numeric",
              minute: "numeric",
            });
            return formatter.format(date);
          }
        },
        backgroundColor: 'rgb(22,26,33)',
        padding: 12,
        borderColor: 'oklab(0.373 -0.00605999 -0.0334556)',
        borderWidth: 0.5,
        boxPadding: 5,
        titleFont: 400,
      },
    },
    interaction: {
      mode: 'nearest',
      axis: 'x',
      intersect: false,
    },
    animation: false,
    animations: {
      colors: false,
      x: false,
    },
    transitions: {
      active: {
        animation: {
          duration: 0
        }
      }
    },
    scales: {
      x: {
        border: {
          display: true,
          color: 'oklab(0.373 -0.00605999 -0.0334556 / 0.7)',
        },
        grid: {
          display: false,
          drawOnChartArea: false,
          drawTicks: true,
        },
        ticks: {
          maxRotation: 45,
          minRotation: 45,
          stepSize: 10,
          callback: function (value, index, ticks) {
            let date = new Date(points[index].time / 1);
            let formatter = new Intl.DateTimeFormat(navigator.language, {
              month: "long",
              day: "numeric",
              hour: "numeric",
              minute: "numeric",
            });
            return formatter.format(date);
          }
        },
        beginAtZero: true,
      },
      y: {
        beginAtZero: true,
        border: {
          display: true,
          color: 'oklab(0.373 -0.00605999 -0.0334556 / 0.7)'
        },
        grid: {
          display: false,
          drawOnChartArea: false,
          drawTicks: true,
        },
        ticks: {
          maxRotation: 0,
          minRotation: 0,
          callback: function (value, index, ticks) {

            let type = language.b;
            let divider = 1;

            if (value >= 1_024) {
              type = language.kb;
              divider = 1_000;
            }
            if (value >= 1_048_576) {
              type = language.mb;
              divider = 1_000_000;
            }
            if (value >= 1_073_741_824) {
              type = language.gb;
              divider = 1_000_000_000;
            }
            if (value >= 1_099_511_627_776) {
              type = language.tb;
              divider = 1_000_000_000_000;
            }

            return value / divider + ' ' + type + '/' + language.second;
          }
        }
      },
    },
  };
  let plugins = [
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
        ctx.setLineDash([1, 1]);
        ctx.strokeStyle = 'oklch(90.5% 0.182 98.111)';
        ctx.stroke()

        ctx.restore()
      }
    }
  ];
  let data = $derived.by(() => {
    let labels = [];
    let dataIn = [];
    let dataOut = [];
    points.forEach(element => {
      labels.push(element.time);
      dataIn.push(element.in);
      dataOut.push(element.out);
    });
    return {
      labels,
      datasets: [
        {
          label: language.in,
          data: dataIn,
          borderColor: 'oklch(72.3% 0.219 149.579)',
          backgroundColor: 'oklch(72.3% 0.219 149.579 / 0.1)',
          ...datasetsOptions
        },
        {
          label: language.out,
          data: dataOut,
          borderColor: 'oklch(62.3% 0.214 259.815)',
          backgroundColor: 'oklch(62.3% 0.214 259.815 / 0.1)',
          ...datasetsOptions
        },
      ]
    };
  });
  let config = $derived({
    type: 'line',
    data,
    options,
    plugins
  });
  let chart = null;

  onMount(() => {
    Chart.register(LineController, LineElement, PointElement, CategoryScale, LinearScale, Tooltip, Filler);
    Chart.defaults.backgroundColor = 'rgba(0, 0, 0, 0)';
    Chart.defaults.borderColor = 'rgba(0, 0, 0, 0)';
    Chart.defaults.color = '#ffffff';
    Chart.defaults.font.size = 12;
    Chart.defaults.font.family = 'Inter';
    Chart.defaults.font.weight = 300;
  });

  $effect(() => {
    if (chart) chart.destroy();
    chart = new Chart(canvas, config);
  });

</script>

<canvas {...props} bind:this={canvas}></canvas>