<script>
  import ProjectIcon from "$lib/components/icons/components/ProjectIcon.svelte";
  
  let {mini_title, title, ...props} = $props();
</script>

<div {...props} class="{props.class} flex justify-center items-center gap-x-4">
  <ProjectIcon title={mini_title}/>
  <h1 class="font-medium">{title}</h1>
</div>