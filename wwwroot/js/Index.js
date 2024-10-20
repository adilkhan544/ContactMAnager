document.addEventListener('DOMContentLoaded', function () {

    document.querySelector("#searchInput").addEventListener("input", (e) => {

        var searchValue = e.target.value.toLowerCase();
        let contacts = document.querySelectorAll(`a[href *= "/contactitems/Details"]`);

        contacts.forEach((contact) => {
            let name = contact.querySelector('h1').innerText.toLowerCase()

            if (name.includes(searchValue)) {
                contact.style.display = "flex"
            }
            else {
                contact.style.display = "none"
            }
        })
    })
})