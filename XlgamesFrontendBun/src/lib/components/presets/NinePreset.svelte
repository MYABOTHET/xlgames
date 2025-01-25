<script>
  let {list = $bindable(), title, Component, onclick, ...props} = $props();
  
  function up(i) {
    let temp = list[i];
    list[i] = list[i - 1];
    list[i - 1] = temp;
  }
  
  function down(i) {
    let temp = list[i];
    list[i] = list[i + 1];
    list[i + 1] = temp;
  }
  
  function deleteItem(index) {
    list.splice(index, 1);
  }
</script>

<div {...props} class="{props.class} flex flex-col gap-y-[inherit] w-fit max-w-full border
border-(--color-hexadecimal) px-5 py-4 min-w-xs">
  <h1 class="text-base font-normal">{title}</h1>
  {#each list as item, index}
    <Component bind:object={list[index]} {index} {up} {down} {deleteItem} length={list.length}/>
  {/each}
  <button {onclick} class="font-normal border border-(--color-hexadecimal) h-8 w-36 rounded-full flex items-center
              justify-center transition-colors hover:bg-(--color-quaternary)/10 text-(--color-quaternary)">
    <span>Добавить</span>
  </button>
</div>