module.exports = Backbone.Model.extend({

    idAttribute: "Id",

    defaults: {
        Id: null,
        Name: "",
        Ingredients: []
    },

    setTotalPrice: function (ingredients) {
        var totalPrice = 0,
            missingIngredients = [],
            allIngredients = this.get("Ingredients");
        
        _.each(ingredients, function (ingredient) {
            var i = _.find(allIngredients, function (i) { return i.Ingredient.Name == ingredient });

            if (!i) {
                missingIngredients.push(ingredient);
                return;
            }

            totalPrice += i.Price;
        }, this);
        
        this.set("MissingIngredients", missingIngredients);
        this.set("TotalPrice", Math.round(totalPrice * 100) / 100);
    },

    getIngredients: function (ingredients) {
        var allIngredients = this.get("Ingredients");

        return _.reject(allIngredients, function (ingredient) {
            return ingredients.indexOf(ingredient.Ingredient.Name) === -1;
        });
    }

});