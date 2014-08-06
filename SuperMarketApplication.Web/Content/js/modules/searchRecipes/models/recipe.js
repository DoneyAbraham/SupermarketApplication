module.exports = Backbone.Model.extend({

    initialize: function () {
        this.on("change:smallImageUrls", this.setImageUrl);
        this.setImageUrl();
    },

    setImageUrl: function () {
        var url = _.first(this.get("smallImageUrls"));

        if (/=s[0-9]+$/.test(url)) {
            url = url.replace(/=s[0-9]+/, "=s500");
        }

        this.set("imageUrl", url);
    }

});