document.addEventListener("DOMContentLoaded", function () {
    const cancelButtons = document.querySelectorAll("[id^='Delete-button-']");

    cancelButtons.forEach(button => {
        button.addEventListener("click", function () {
            const postId = this.id.split("-")[2];
            console.log("ok", postId)
            const cardElement = document.getElementById(card - ${ postId });

            //if (cardElement) {
            //    cardElement.style.backgroundColor = "red";
            //}
        });
    });
});