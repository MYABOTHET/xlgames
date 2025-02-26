<script>
  let interfaces = $state([]);
  let currentInterface = $state({});
  let inputInterface = $state({});
  let input = $state("");
  
  function selectInterface(item) {
    currentInterface = item;
  }
  
  function createInput() {
    inputInterface[input] = "";
    input = "";
  }
  
  function createInterface() {
    interfaces.push(inputInterface);
    inputInterface = {};
  }
</script>

Все интерфейсы
<br>
{#each interfaces as item, i}
  <button style="color: {currentInterface?.name === interfaces[i].name ? 'black' : 'gray'}"
          onclick={() => selectInterface(interfaces[i])}>{i + 1} + {interfaces[i].name}</button><br>
{/each}

<br>
{#each Object.entries(currentInterface) as item}
  <input bind:value={currentInterface[item[0]]}><br>
{/each}
<br>
<br>

<input placeholder="Имя интерфейса" bind:value={inputInterface.name}><br>
<button onclick={createInterface}>Создать новый интерфейс</button><br>

<input placeholder="Имя нового поля" bind:value={input}><br>
<button onclick={createInput}>Создать новое поле</button><br>