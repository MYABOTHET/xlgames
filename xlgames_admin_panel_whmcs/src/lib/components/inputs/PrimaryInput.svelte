<script>
  let {value = $bindable(), ...props} = $props();
</script>

<input bind:value spellcheck="false" {...props} autocomplete="off" placeholder="{props.placeholder ?? 'Введите ключ...'}"
       class="{props.class} outline-none px-4 py-2 min-w-[20rem] max-w-[44rem] w-full text-2xl rounded-lg border">