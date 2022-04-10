<template>
  <div class="container-fluid">
    <div class="row container-fluid justify-content-center">
      <div class="col-md-11 banner rounded-3 mt-3 d-flex shadow"></div>
      <div
        class="
          col-md-6
          bg-dark
          d-flex
          justify-content-around
          rounded
          selection-bar
          align-items-center
          shadow
        "
      >
        <h3>All</h3>
        <h3>Favorites</h3>
        <h3>My recipes</h3>
      </div>
    </div>
    <div class="row">
      <!-- iterate over recipes -->
      <div v-for="r in recipes" :key="r.id" class="col-md-3 m-3 p-1">
        <RecipeCard :recipe="r" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { watchEffect } from '@vue/runtime-core'
import { recipesService } from '../services/RecipesService'
export default {
  name: 'Home',
  setup() {

    watchEffect(async () => {
      try {
        await recipesService.getAll()
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }

    })
    return {
      recipes: computed(() => AppState.recipes)
    }
  }



}
</script>

<style scoped lang="scss">
.selection-bar {
  height: 7vh;

  transform: translateY(-35%);
}
.banner {
  height: 30vh;
  background-image: url("https://www.idhsustainabletrade.com/uploaded/2018/04/Spices-1-1440x400-c-default@1x.jpeg");
  background-size: cover;
}
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card {
    width: 50vw;
    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
