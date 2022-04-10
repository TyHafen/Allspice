import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {
    async getAll() {
        const res = await api.get('api/recipes')
        logger.log("getting recipes", res.data)
        AppState.recipes = res.data
        logger.log(AppState.recipes)
    }



}

export const recipesService = new RecipesService()