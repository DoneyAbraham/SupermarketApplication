module.exports = Backbone.Collection.extend({

    model: require("../models/history.js"),

    url: function () {
        return "/api/history/" + userId;
    }

});