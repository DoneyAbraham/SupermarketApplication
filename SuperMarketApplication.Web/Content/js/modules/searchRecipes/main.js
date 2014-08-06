var RecipesCollection = require("./collections/recipes.js"),
    RecipesView = require("./views/recipes.js"),
    SearchView = require("./views/search.js"),
    CartView = require("./views/cart.js");

module.exports = function () {
    var recipes = new RecipesCollection();
    
    new RecipesView({
        collection: recipes
    });

    new SearchView({
        collection: recipes
    });

    new CartView();
};