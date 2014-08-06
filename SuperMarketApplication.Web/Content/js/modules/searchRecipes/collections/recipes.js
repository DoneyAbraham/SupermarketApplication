var RecipeModel = require("../models/recipe.js");

module.exports = Backbone.Collection.extend({

    params: {
        _app_id: "80adc1eb",
        _app_key: "6e3cb905a1028abd81ae30f6b7194107",
        requirePictures: true,
        maxResult: 10,
        start: 0
    },

    request: null,

    model: RecipeModel,

    url: "http://api.yummly.com/v1/api/recipes",

    comparator: "rating",

    search: function (query) {
        var self = this;

        if (!query) {
            this.reset([]);
            this.trigger("search:cancel");
            App.trigger("search:cancel");
            return;
        }

        this.trigger("search:begin");

        if (this.request != null) {
            this.request.abort();
        }

        this.request = this.sync("read", this, {
            query: query,
            success: function (response) {
                self.reset([]);
                self.set(response, { parse: true });
                self.trigger("search:results", response)
                    .trigger("search:end");

                App.trigger("search:results", self);
            }
        });
    },

    sync: function (method, collection, options) {
        options.data = _.extend({
            q: options.query
        }, this.params);

        options.crossDomain = true;
        options.dataType = 'jsonp';

        return Backbone.sync.call(this, method, collection, options);
    },

    parse: function (response) {
        return response.matches;
    }

});