<template>
  <div class="component">
    <div class="card bg-dark text-white shadow border-0 selectable">
      <img
        class="card-img"
        src="https://www.takeaway.com/foodwiki/uploads/sites/11/2019/08/italian_cuisine_1-1080x985.jpg"
        alt="Card image"
      />
      <div class="card-img-overlay">
        <div class="row">
          <h4 class="card-title">{{ recipe.category }}</h4>
        </div>
      </div>
      <div class="row p-3">
        <h3>{{ recipe.title }}</h3>
        <h4>{{ recipe.subtitle }}</h4>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  props: {
    recipe: {
      type: Object,
      required: true

    }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
</style>