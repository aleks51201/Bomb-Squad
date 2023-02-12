﻿mergeInto(LibraryManager.library, {
    Hello: function () {
        window.alert("Hello, world!");
        console.log("Hello world");
    },
    IsPlayerAuthorized: function () {
        if (player.getMode() != 'lite') {
            return 1;
        }
        return 0;
    },
    AuthPlayer: function () {
        var result = 0;
        ysdk.auth.openAuthDialog()
            .then(_result => result + 1)
            .catch(_result => result = 0);
        initPlayer()
            .then()
            .catch();
        return result;
    },
    SetLeaderBoardScore: function (score) {
        ysdk.getLeaderboards()
            .then(lb => {
                lb.setLeaderboardScore('leaderboard2021', score);
            });
    },
    GetLeaderBoardScore: function () {
        var score = ysdk.getLeaderboards()
            .then(lb => lb.getLeaderboardPlayerEntry('leaderboard2021').score)
            .catch(err => {
                if (err.code === 'LEADERBOARD_PLAYER_NOT_PRESENT') {
                    // Срабатывает, если у игрока нет записи в лидерборде
                    return 0;
                }
            });
        return score;
    },
    ConsoleLog: function (str) {
        console.log(UTF8ToString(str));
    },
});