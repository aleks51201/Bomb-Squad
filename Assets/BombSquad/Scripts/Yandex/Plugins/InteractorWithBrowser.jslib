mergeInto(LibraryManager.library, {
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
        ysdk.auth.openAuthDialog()
            .then(_result => {
                initPlayer()
                    .then(() => {return 1;})
                    .catch(() => {return 0;});
            })
            .catch(() => {return 0});
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