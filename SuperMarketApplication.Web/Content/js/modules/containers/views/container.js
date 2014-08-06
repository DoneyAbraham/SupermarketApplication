var ContainerTemplate = require("../templates/container.html");

module.exports = Backbone.View.extend({

    tagName: "section",
    template: _.template(ContainerTemplate),

    events: {
        "click .btn-delete": "destroy"
    },

    initialize: function () {
        this.listenTo(this.model, "change:Name", this.renderName)
            .listenTo(this.model, "destroy", this.remove)
            .listenTo(App, "recipe:mouseover", this.distinguishIngredients)
            .listenTo(App, "recipe:mouseout", this.resetIngredients)
            .listenTo(App, "containers:search", this.filter);

        return this.render();
    },

    render: function () {
        this.$el.html($.trim(this.template(this.model.toJSON())));
        return this;
    },

    distinguishIngredients: function (model) {
        var ingredients = model.get("ingredients"),
            ingredientsInContainer = [];

        this.resetIngredients();
        
        this.$("li").each(function () {
            var li = $(this),
                text = $.trim(li.text());
            
            _.each(ingredients, function (ingredient) {
                ingredient = $.trim(ingredient);
                if((text.indexOf(ingredient) > -1) || (ingredient.indexOf(text)) > -1) {
                    li.addClass("highlight");
                    ingredientsInContainer.push(ingredient);
                }
            });
        });

        App.trigger("ingredients", ingredientsInContainer);
    },

    resetIngredients: function () {
        this.$("li").removeClass("highlight filter-hidden");
    },

    filter: function (query) {
        var matches = 0;

        if (!query) {
            this.$el.removeClass("hide");
            return this.resetIngredients();
        }

        this.$("li").each(function () {
            var li = $(this),
                text = $.trim(li.text()).toLowerCase();

            if (text.indexOf(query) === -1) {
                li.addClass("filter-hidden");
            } else {
                if (li.hasClass("filter-hidden")) {
                    li.removeClass("filter-hidden");
                }

                matches++;
            }
        });
        
        if (!matches) {
            this.$el.addClass("hide");
        } else if(this.$el.hasClass("hide")) {
            this.$el.removeClass("hide");
        }
    },

    destroy: function () {
        this.model.destroy();
    }

});