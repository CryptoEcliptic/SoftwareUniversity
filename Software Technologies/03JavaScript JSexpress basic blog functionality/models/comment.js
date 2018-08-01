const Sequelize = require('sequelize');

module.exports = (sequelize) => {
    const Comment = sequelize.define('Comment', {

        content: {
            type: Sequelize.STRING,
            require: true,
            allowNull: false
        },
    });
    Comment.associate = (models) => {
        Comment.belongsTo(models.User, {
            foreignKey: 'authorId',
            targetKey: 'id'
        });
        Comment.belongsTo(models.Article, {
            foreignKey: 'articleId',
            targetKey: 'id'
        });

    };
    return Comment;
};