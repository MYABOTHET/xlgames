<script>
  import Load from "$lib/components/icons/svg/Load.svelte";
  
  let {src, ...props} = $props();
  let opacity = $state(true);
  let success = $state(false);
  
  function success_img() {
    opacity = false;
    success = true;
  }
</script>

<div {...props} class="{props.class} relative">
  <img alt="" class="{opacity ? 'opacity-0' : 'opacity-100'} absolute
         -z-20 h-full w-full object-cover"
       onload={success_img} {src}/>
  {#if !success}
    <div class="w-full h-full -z-30 flex absolute justify-center items-center">
      <Load class="h-6 fill-xlgames-2"/>
    </div>
  {/if}
</div>