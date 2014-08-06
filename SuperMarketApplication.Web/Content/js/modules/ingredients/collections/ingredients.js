module.exports = Backbone.Collection.extend({

    model: require("../models/ingredient.js"),

    url: "/api/ingredients"

});