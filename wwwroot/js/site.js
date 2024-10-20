
window.addEventListener("load", function () {
    const preloader = document.getElementById("preloader");
    preloader.style.opacity = "0";
    preloader.style.visibility = "hidden";
    preloader.style.transition = "visibility 0s 0.5s, opacity 0.5s ease";
});






// Details page

window.onload = function () {
    const defaultImage = "https://png.pngtree.com/png-vector/20221125/ourmid/pngtree-no-image-available-icon-flatvector-illustration-pic-design-profile-vector-png-image_40966566.jpg"; // Default image ka path

    document.querySelectorAll('img').forEach(img => {
        img.onerror = function () {
            this.onerror = null; // Prevent infinite loop
            this.src = defaultImage; // Default image set karein
        };
    });
};