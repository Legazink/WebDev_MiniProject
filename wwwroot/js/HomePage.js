const postData = window.postData;
const currentUser = window.currentUser;
const timeNow = window.timeNow;
const year = window.year;
const month = window.month;
const day = window.day;
const hour = window.hour;
const min = window.min;
const sec = window.sec;

postData.forEach(post => {
    const postId = post.postId;
    let allTime = post.time.split(":");
    let allDate = post.date.split("-");
    var postYear = parseInt(allDate[0]);
    var postMonth = parseInt(allDate[1]);
    var postDay = parseInt(allDate[2]);
    var postHour = parseInt(allTime[0]);
    var postMin = parseInt(allTime[1]);
    //console.log(post.gameName);
    //console.log(post.joinedNumber);
    //console.log(post.number);

    console.log(postHour, postMin, postYear, postMonth, postDay);
    console.log(hour, min, year, month, day);

    if (new Date(year, month, day, hour, min, sec) > new Date(postYear, postMonth, postDay, postHour, postMin, 0))
    {
        var selector = "#join-button-";
        selector += postId;
        button = document.querySelector(selector);

        button.style.backgroundColor = "Gray";
        button.style.cursor = "auto";
        button.disabled = true;
        button.innerText = "CLOSED"
        //console.log(post.gameName);
    }

    else if (post.postOwner == currentUser || post.joinedNumber == post.number)
    {
        var selector = "#join-button-";
        selector += postId;
        button = document.querySelector(selector);
        button.style.cursor = "auto";
        button.disabled = true;
        button.style.backgroundColor = "Gray";

        button.innerText = "JOINED";
    }
    else {
        post.postJoinedAll.forEach(joined => {
            if (joined.joinedUserName == currentUser) {
                var selector = "#join-button-";
                selector += postId;
                button = document.querySelector(selector);

                button.disabled = true;
                button.style.backgroundColor = "Gray";
                button.style.cursor = "auto";
                button.innerText = "JOINED";
            }
        });
    }
});