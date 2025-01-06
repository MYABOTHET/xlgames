<script>
  import ProjectLogo from "$lib/components/Project/ProjectLogo.svelte";
  
  const {logo, name, ...props} = $props();
</script>

<div {...props} class="{props.class} flex items-center gap-x-4 font-medium w-fit">
  <ProjectLogo>{logo}</ProjectLogo>
  <h1 class="relative top-[0.5px]">{name}</h1>
</div>