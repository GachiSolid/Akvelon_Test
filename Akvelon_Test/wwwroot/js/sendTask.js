// send project form
document.forms["taskForm"].addEventListener("submit", e => {
    e.preventDefault();
    const form = document.forms["taskForm"];
    const name = form.elements["name"].value;
    const description = form.elements["description"].value;
    var priority = form.elements["priority"].value;
    if (priority === "") priority = 0;
    CreateTask(name, description, priority);
    form.reset();
    var modal = document.getElementById("myModal");
    modal.style.display = "none";
});