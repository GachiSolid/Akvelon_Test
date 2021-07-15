var project;
async function GetProject() {
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get("id");
    const response = await fetch("/api/project/"+id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        project = await response.json();
        UpdateForm(project);
        const tasks = project.tasks;
        tasks.sort(sortByPriority());
        let rows = document.querySelector("tbody");
        while (rows.hasChildNodes()) {
            await rows.removeChild(rows.firstChild);
        }
        tasks.forEach(task => {
            rows.append(row(task));
        });
    }
}

function row(task) {
    const tr = document.createElement("tr");
    tr.className = "even";
    tr.onclick = function () {
        window.location.href = "/Home/Edit/?id=" + task.id;
    }

    const nameTd = document.createElement("td");
    nameTd.append(task.name);
    tr.append(nameTd);

    const statusTd = document.createElement("td");
    switch (task.status) {
        case 0:
            statusTd.append("To Do");
            break;
        case 1:
            statusTd.append("In Progress");
            break;
        case 2:
            statusTd.append("Done");
            break;
    }
    tr.append(statusTd);

    const deskTd = document.createElement("td");
    deskTd.append(task.description);
    tr.append(deskTd);

    const removeTd = document.createElement("td");
    const removeLink = document.createElement("a");
    removeLink.setAttribute("class", "textA glyphicon glyphicon-trash btn btn-default btn-sm");
    removeLink.addEventListener("click", e => {

        e.preventDefault();
        e.stopPropagation();
        DeleteTask(task.id);
    });

    removeTd.append(removeLink);
    tr.appendChild(removeTd);

    return tr;
}

async function CreateTask(name, description, priority) {
    //const startDate = JSON.stringify(new Date());
    const response = await fetch("/api/task", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            name: name,
            description: description,
            priority: priority,
            projectId: project.id
        })
    });
    if (response.ok === true) {
        GetProject();
    }
}

async function DeleteTask(id) {
    const response = await fetch("/api/task/?id=" + id, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        GetProject();
    }
}

async function UpdateProject(name, compDate, status, priority) {
    const response = await fetch("/api/project", {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            id: project.id,
            name: name,
            startDate: project.startDate,
            completeDate: compDate,
            status: status,
            priority: priority,
            tasks: project.tasks
        })
    });
    if (response.ok === true) {
        GetProject();
    }
}

function UpdateForm(project) {
    const form = document.forms["projectForm"];
    form.elements["name"].value = project.name;
    form.elements["priority"].value = project.priority;
    form.elements["status"].value = project.status;

    form.addEventListener("submit", e => {
        e.preventDefault();
        const name = form.elements["name"].value;
        const priority = form.elements["priority"].value;
        const status = form.elements["status"].value;
        var compDate = null;
        if (status === "2") compDate = new Date();
        UpdateProject(name, compDate, status, priority);
    });
}
function sortByPriority() {
    return function (a, b) {
        if (a["priority"] < b["priority"])
            return 1;
        else if (a["priority"] > b["priority"])
            return -1;

        return 0;
    }
}
GetProject();