const Sequelize = require('sequelize');

module.exports = function (sequelize) {
    return sequelize.define("Cat", {
        name: {
            type: Sequelize.TEXT,


        },
        nickname: {
            type: Sequelize.TEXT,

        },

        price: {
            type: Sequelize.DOUBLE,

        }
    }, {
        timestamps: false
    });
};