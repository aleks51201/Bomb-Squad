﻿mergeInto(LibraryManager.library, {
    Hello: function () {
        window.alert("Hello, world!");
        console.log("Hello world");
    },
    no: function () {
        initPlayer().then(_player => {
        if (_player.getMode() === 'lite') {
            // Игрок не авторизован.
            ysdk.auth.openAuthDialog().then(() => {
                    // Игрок успешно авторизован
                    initPlayer().catch(err => {
                        // Ошибка при инициализации объекта Player.
                    });
                }).catch(() => {
                    // Игрок не авторизован.
                });
        }
        }).catch(err => {
            // Ошибка при инициализации объекта Player.
        });
    },
    IsPlayerAuthorized: function () {
        if (player.getMode() != 'lite') {
            return 1;
        }
        return 0;
    },
    AuthPlayer: function () {
        initPlayer().then(_player => {
        if (_player.getMode() === 'lite') {
            // Игрок не авторизован.
            ysdk.auth.openAuthDialog().then(() => {
                    // Игрок успешно авторизован
                return 1;
                    initPlayer().catch(err => {
                        // Ошибка при инициализации объекта Player.
                        return 0;
                    });
                }).catch(() => {
                    // Игрок не авторизован.
                    return 0;
                });
        }
        }).catch(err => {
            // Ошибка при инициализации объекта Player.
            return 0;
        });
    },
    SetLedearBoardScore: function (score) {
        ysdk.getLeaderboards()
          .then(lb => {
            lb.setLeaderboardScore('leaderboard2021', score);
          });
    },
    GetLedearBoardScore: function () {
        var score = ysdk.getLeaderboards()
          .then(lb => lb.getLeaderboardPlayerEntry('leaderboard2021'))
          .catch(err => {
            if (err.code === 'LEADERBOARD_PLAYER_NOT_PRESENT') {
              // Срабатывает, если у игрока нет записи в лидерборде
                return 0;
            }
          }).score;
        return score;
    },
});