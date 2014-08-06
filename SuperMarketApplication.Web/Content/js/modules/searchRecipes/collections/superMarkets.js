module.exports = Backbone.Collection.extend({

    _hasSearched: false,
    _query: null,

    model: require("../models/superMarket.js"),

    url: "/api/superMarkets",

    findByIngredients: function (ingredients) {
        var baseUrl = _.result(this, "url"),
            params = $.param({ ingredients: ingredients });

        if (this._hasSearched) {
            return this;
        }

        this._hasSearched = true;

        this._query = this.fetch({
            url: baseUrl + "?" + params
        });

        return this._query;
    },

    cancelSearch: function () {
        if (this._query) {
            this._query.abort();
        }
    }

});