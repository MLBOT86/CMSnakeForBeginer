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


SaveExtern: function(date){
var dateString = UTF8ToString(date);
var myobj = JSON.parse(dateString);
player.setData(myobj);
},

LoadExtern:function(){

player.getData().then (_date=>{
    const myJSON = JSON.stringify(_date);
    myGameInstance.SendMessage('SaveProgress','SetPlayerInfo',myJSON);
});
},

SetToLeaderboard : function(value){
ysdk.getLeaderboards()
  .then(lb => {
    // Без extraData.
    lb.setLeaderboardScore('Experience', value);
   
  });



},

GetLang: function(){
var lang =ysdk.environment.i18n.lang;
var bufferSize = lengthBytesUTF8(lang)+1;
var buffer = _malloc(bufferSize);
stringToUTF8(lang,buffer,bufferSize);


    return buffer;
},


ShowAdv: function(){
ysdk.adv.showFullscreenAdv({
    callbacks: {
onOpen: () => {
                console.log('Open Ad Interstitial');
                myGameInstance.SendMessage('Yandex', 'GamePause');
               },


        onClose: function(wasShown) {

            console.log("------------------closed-------------");
             myGameInstance.SendMessage('Yandex', 'GameResume');
          // Действие после закрытия рекламы.
        },
        onError: function(error) {
          // Действие в случае ошибки.
        }
    }
})


},




});