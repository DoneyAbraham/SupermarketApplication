var ContainersCollection = require("./collections/containers.js"),
    ContainersView = require("./views/containers.js");
    HeaderView = require("./views/header.js"),
    HistoryView = require("./views/history.js");

module.exports = function (currentUser) {
    var collection = new ContainersCollection(null, { user: currentUser });

    new ContainersView({
        collection: collection
    });

    new HeaderView({
        collection: collection
    });

    new HistoryView();

    collection.fetch();
};