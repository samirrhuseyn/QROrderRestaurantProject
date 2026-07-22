
const input = document.getElementById("imageInput");
const preview = document.getElementById("preview");

input.addEventListener("change", function () {

    if (this.files && this.files[0]) {

        const reader = new FileReader();

        reader.onload = function (e) {
            preview.src = e.target.result;
        };

        reader.readAsDataURL(this.files[0]);
    }

});
