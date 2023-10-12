// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

url = "/api/Members";

$(document).ready(() => {

    $.getJSON(url, (members) => {

        members.forEach(member => {

            $('#tblMembers tbody')
                .append(`<tr>
                    <td>${member.id}</td>
                    <td>${member.name}</td>
                    <td>${member.email}</td>
                    <td>${member.active ? "Active" : "Inactive"}</td>
                </tr>`);
        })
        
    })
});


