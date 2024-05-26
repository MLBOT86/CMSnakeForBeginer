mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
   
  },
// метод что бы закинуть куда нибудь фото и имя игрока
GiveMePlayerData: function () {
myGameInstance.SendMessage('Yandex', 'SetName',player.getName());
myGameInstance.SendMessage('Yandex', 'SetPhoto',player.getPhoto("medium"));


  },
  

// метод для оценки игры 

   RateGame: function () {
    
ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })

   
  },


});