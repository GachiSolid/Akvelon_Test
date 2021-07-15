async function GetTask() {
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get("id");
    const response = await fetch("https://localhost:44310/api/task/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const task = await response.json();
        UpdateTaskForm(task);
    }
}

function UpdateTaskForm(task) {
    const form = document.forms["taskPutForm"];
    form.elements["name"].value = task.name;
    form.elements["description"].value = task.description;
    form.elements["priority"].value = task.priority;
    form.elements["status"].value = task.status;

    form.addEventListener("submit", e => {
        e.preventDefault();
        task.name = form.elements["name"].value;
        task.description = form.elements["description"].value;
        task.priority = form.elements["priority"].value;
        task.status = form.elements["status"].value;
        UpdateTask(task);
    });
}

async function UpdateTask(task) {
    const response = await fetch("https://localhost:44310/api/task", {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            id: task.id,
            name: task.name,
            status: task.status,
            description: task.description,
            priority: task.priority,
            projectId: task.projectId
        })
    });
    if (response.ok === true) {
        window.location.href = "/Home/Project/?id=" + task.projectId;
    }
}
GetTask();

