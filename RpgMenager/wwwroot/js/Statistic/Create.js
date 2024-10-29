$(document).ready(function () {
    const LoadStatistics = () => {
        const container = $("#statistics-container");
        const id = container.data("id-name");

        $.ajax({
            url: `/Character/${id}/Statistic`,
            type: 'get',
            success: function (data) {
                console.log(data); // Sprawdzenie struktury danych zwróconych z serwera

                if (!data || !data.length) {
                    container.html("No statistics available");
                    return;
                }

                // Wyczyść główny kontener tylko raz przed iteracją
                container.empty();

                // Iteracja po `data`, jeśli jest to lista `StatisticIndexDto`
                data.forEach((statisticIndex, index) => {
                    if (statisticIndex.mainList && statisticIndex.mainList.length > 0) {
                        // Tworzenie nowego podkontenera dla każdego `statisticIndex`
                        const subContainer = $('<div class="statistic-sub-container"></div>');
                        container.append(subContainer);

                        // Renderowanie statystyk do nowego podkontenera
                        RenderStatistics(statisticIndex.mainList, subContainer, `Statistic Index ${index + 1}`);
                    }
                });
            },
            error: function () {
                toastr["error"]("POSZŁO ŹLE1");
            }
        });
    };

    // Zmieniona funkcja RenderStatistics, aby nie czyściła głównego kontenera
    const RenderStatistics = (statistics, container, title) => {
        const table = `
    <div class="col-md-6">
        <h2>${title}</h2>
        <table class="table">
            <thead>
                <tr>
                    <th>Value</th>
                    <th>Statistics Enum</th>
                    <th>List Id</th>
                    <th>Name Of The List</th>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Encoded Name</th>
                    <th>Path To Image</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                ${statistics.map(item => `
                <tr>
                    <td>${item.value}</td>
                    <td>${item.statisticsEnum}</td>
                    <td>${item.listId}</td>
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

        // Dodanie tabeli do kontenera przekazanego jako parametr
        container.append(table);
    };

    LoadStatistics();

    $("#createStatisticModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created carworkshop service");
                LoadStatistics();
            },
            error: function () {
                toastr["error"]("POSZŁO ŹLE2");
            }
        });
    });
});
