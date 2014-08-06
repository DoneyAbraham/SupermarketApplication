var Recipes = require("./modules/searchRecipes/main.js"),
    Login = require("./modules/user/views/login.js"),
    UserModel = require("./modules/user/models/user.js"),
    Containers = require("./modules/containers/main.js"),
    currentUser = new UserModel({ Id: userId, FirstName: userName });

window.App = _.extend({
    moment: require("./vendor/moment.js")
}, Backbone.Events);

Recipes(currentUser);
Containers(currentUser);

new Login();