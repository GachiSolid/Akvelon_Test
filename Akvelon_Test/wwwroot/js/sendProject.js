// send project form
document.forms["projectForm"].addEventListener("submit", e => {
    e.preventDefault();
    const form = document.forms["projectForm"];
    const name = form.elements["name"].value;
    var priority = form.elements["priority"].value;
    if (priority === "") priority = 0;
    CreateProject(name, priority);
    form.reset();
    var modal = document.getElementById("myModal");
    modal.style.display = "none";
});