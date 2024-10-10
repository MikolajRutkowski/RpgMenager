$(document).ready(function () {
    const RenderStatistics = (statistics, container, title) => {
        container.empty();

        const table = `
        <div class="col-md-6">
            <h2>${title}</h2>
            <table class="table">
                <thead>
                    <tr>
                        <th>Value</th>
                        <th>CharacterId</th>
                        <th>NameOfTheList</th>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>EncodedName</th>
                        <th>PathToImage</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    ${statistics.map(item => `
                    <tr>
                        <td>${item.value}</td>
                        <td>${item.characterId}</td>
                        <td>${item.nameOfTheList}</td>
                        <td>${item.id}</td>
                        <td>${item.name}</td>
                        <td>${item.description}</td>
                        <td>${item.encodedName}</td>
                        <td>${item.pathToImage}</td>
                        <td>
                            <a href="/Edit/${item.id}">Edit</a> |
                            <a href="/Details/${item.id}">Details</a> |
                            <a href="/Delete/${item.id}">Delete</a>
                        </td>
                    </tr>`).join('')}
                </tbody>
            </table>
        </div>
    `;

        container.append(table);
    };

    const LoadStatistics = () => {
        const container = $("#statistics-container");
        const encodedName = container.data("encodedName");
        const idName = container.data("idName");

        $.ajax({
            url: `/Character/${encodedName}/Statistic?idName=${idName}`,
            type: 'get',
            success: function (data) {
                if (!data.length) {
                    container.html("No statistics available");
                    return;
                } else {
                    RenderStatistics(data, container,"Lista Statystyk")
                }

                //const group1 = data.filter(item => item.statisticsEnum === 'Character');
                //const group2 = data.filter(item => item.statisticsEnum === 'Skill');

                //if (group1.length > 0) {
                //    RenderStatistics(group1, container, 'Statistics EnumValue1');
                //}
                //if (group2.length > 0) {
                //    RenderStatistics(group2, container, 'Statistics EnumValue2');
                //}
            },
            error: function () {
                toastr["error"]("Something went wrong");
            }
        });
    };

    LoadStatistics();

    


    $("#createStatisticModal form").submit(function(event) {
        event.preventDefault();

        $.ajax({
        url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function(data) {
                toastr["success"]("Created carworkshop service")
                LoadStatistics();
            },
            error: function() {
                toastr["error"]("Something went wrong")
            }
        })
    });
});