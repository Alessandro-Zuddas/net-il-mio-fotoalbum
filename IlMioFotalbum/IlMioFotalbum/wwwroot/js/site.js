// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const loadFoto = (filter) => {
    getFotos(filter)
    .then(res => {
        const fotos = res.data;
        renderFotos(fotos);
    });
}

const getFotos = name => axios.get("api/foto", name ? { params: { name } } : {  });

const renderFotos = fotos => {
    const fotosBody = document.querySelector("#ms-fotos");
    fotosBody.innerHTML = fotos.map(fotoComponent).join("");
};

const fotoComponent = foto => `
            <div class="col py-2">
                <div class="card" style="width: 18rem; height: 28rem;">
                    <img src="${foto.imgPath}" class="card-img-top" alt="${ foto.name }">
                    <div class="card-body">
                    <h5 class="card-title">${ foto.name }</h5>
                    <p class="card-text">${ foto.description }</p>
                    <a href="/foto/detail/${ foto.id }" class="btn btn-success">
                        Dettagli
                    </a>
                    </div>
                </div>
            </div>
        `;

const initFilter = () => {
    const filter = document.querySelector("#foto-filter input");

    filter.addEventListener("input", (e) => loadFoto(e.target.value));
};

function submitForm(e) {
    e.preventDefault();

    const email = document.getElementById("ms-email").value;
    const message = document.getElementById("ms-message").value;

    axios.post("api/contactus", { email, message })
        .then(res => {
            console.log(res.data);
        }).catch(err => {
            console.error(err);
        });
};