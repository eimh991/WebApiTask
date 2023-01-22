async function GetMessages() {
    const response = await fetch("/api/message", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        const messages = await response.json();
        let rows = document.querySelector("tbody");
        messages.forEach(message => {
            rows.append(row(message));
        })
    }
}

function row(message) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", message.id);

    const createdTimeTd = document.createElement("td");
    createdTimeTd.append(message.created);
    tr.append(createdTimeTd);

    const numberTd = document.createElement("td");
    numberTd.append(message.phoneNumber);
    tr.append(numberTd);

    const textMessageTd = document.createElement("td");
    textMessageTd.append(message.messageText);
    tr.append(textMessageTd);

    const statusTd = document.createElement("td");
    statusTd.append(message.status);
    tr.append(statusTd);

    return tr;
}

async function CreateMessage(number, text, name) {
         const response = await fetch("/api/message", {
         method: "POST",
         headers: { "Accept": "application/json", "Content-Type": "application/json" },
         body: JSON.stringify({
         phoneNumber: number,
         messageText: text,
         sendername : name
         })
     });
     if (response.ok === true) {
          const message = await response.json();
          const r = document.querySelector('tbody');
          r.append(row(message));
          reset();
     }
}

document.forms["messageForm"].addEventListener("submit", e => {
    e.preventDefault();
    const form = document.forms["messageForm"];
    const number = form.elements["phoneNumber"].value;
    const text = form.elements["textMessage"].value;
    const name = form.elements["name"].value;
    CreateMessage(number, text,name);
});


    function reset() {
        const form = document.forms["messageForm"];
        form.reset();
}

GetMessages();
  
  




