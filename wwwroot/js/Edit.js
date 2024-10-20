let uploadImageButton = document.querySelector("#uploadImageButton");
let uploadImage = document.querySelector("#uploadImage");

uploadImage.addEventListener('click', () => {
    uploadImageButton.click();
});

uploadImageButton.addEventListener('change', function () {
    if (this.files && this.files[0]) {
        uploadImage.src = URL.createObjectURL(this.files[0]);
    }
});
