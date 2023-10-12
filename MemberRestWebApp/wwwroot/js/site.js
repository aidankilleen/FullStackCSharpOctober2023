// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

url = "/api/Members";

function onDelete(id) {
    if (confirm(`Are you sure you want to delete ${id}`)) {
        $.ajax({
            url: `/api/Members/${id}`, 
            method: "delete", 
            success: () => {
                $(`#tr_${ id }`).remove();
            }, 
            error: (error) => {
                alert("error:" + error);
            }
        });
    }
}
$(document).ready(() => {
    $.getJSON(url, (members) => {
        members.forEach(member => {

            $('#tblMembers tbody')
                .append(`<tr id="tr_${ member.id }">
                    <td>${member.id}</td>
                    <td>${member.name}</td>
                    <td>${member.email}</td>
                    <td>${member.active ? "Active" : "Inactive"}</td>
                    <td><button onclick="onDelete(${member.id})" class="btn btn-danger">Delete</button></td>
                </tr>`);
        })
    })
});


