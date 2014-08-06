module.exports = Backbone.Collection.extend({

    model: require("../models/container.js"),

    url: "/api/containers",

    initialize: function (models, options) {
        this.user = options.user;
    },

    create: function (model, options) {
        model.UserId = this.user.id;
        return Backbone.Collection.prototype.create.call(this, model, options);
    },

    sync: function (method, collection, options) {
        options = options || {};
        options.data = options.data || {};

        options.data.userId = this.user.id;

        return Backbone.sync.call(this, method, collection, options);
    }

});