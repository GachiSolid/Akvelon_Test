async function GetProjects() {
    const response = await fetch("/api/project", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {

        const projects = await response.json();
        let rows = document.querySelector("tbody");
        while (rows.hasChildNodes()) {
            rows.removeChild(rows.firstChild);
        }
        projects.forEach(project => {
            rows.append(row(project));
        });
    }
}
function row(project) {
    const tr = document.createElement("tr");
    tr.className = "even";
    tr.onclick = function () { ShowTasks(project.id)}

    const nameTd = document.createElement("td");
    nameTd.append(project.name);
    tr.append(nameTd);

    const dateStartTd = document.createElement("td");
    const date = new Date(project.startDate);
    const startDatestring = date.getDate() + "." + (date.getMonth() + 1) + "." + date.getFullYear();
    dateStartTd.append(startDatestring);
    tr.append(dateStartTd);

    const dateCompTd = document.createElement("td");
    var compDatestring = "TBA";
    if (project.completeDate != null) {
        const date = new Date(project.completeDate);
        compDatestring = date.getDate() + "." + (date.getMonth() + 1) + "." + date.getFullYear();
    }
    dateCompTd.append(compDatestring);
    tr.append(dateCompTd);

    const statusTd = document.createElement("td");
    switch (project.status) {
        case 0:
            statusTd.append("Not Started");
            break;
        case 1:
            statusTd.append("Active");
            break;
        case 2:
            statusTd.append("Completed");
            break;
    }
    tr.append(statusTd);

    const removeTd = document.createElement("td");
    const removeLink = document.createElement("a");
    removeLink.setAttribute("class", "textA glyphicon glyphicon-trash btn btn-default btn-sm");
    removeLink.addEventListener("click", e => {

        e.preventDefault();
        e.stopPropagation();
        DeleteProject(project.id);
    });

    removeTd.append(removeLink);
    tr.appendChild(removeTd);

    return tr;
}
async function CreateProject(name, priority) {
    const response = await fetch("/api/project", {
        method: "POST",
        headers: {"Content-Type": "application/json" },
        body: JSON.stringify({
            name: name,
            startDate: new Date(),
            priority: priority
        })
    });
    if (response.ok === true) {
        GetProjects();
    }
}
async function DeleteProject(id) {
    const response = await fetch("/api/project/?id=" + id, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        GetProjects();
    }
}
function ShowTasks(id) {
    window.location.href = "/Home/Project/?id="+id;
}
GetProjects();