(function () {
    // Generates a random string (GUID)
    function uuidv4() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }

    $.fn.GenerateUUID = uuidv4;

    $.fn.WeRentCar123TableFilter = function ({ url }) {
        const $this = this;

        $this.Fetch = function (dateFilter) {
            let route = url;
            if (dateFilter) route = route + '?date=' + dateFilter.toISOString();

            console.log('Fetcched', route);

            $.getJSON(route, function (response) {
                console.warn('Route', response);
                let filterButtonID = $.fn.GenerateUUID();
                let dateFilterINput = $.fn.GenerateUUID();
                let rows = response.map(r => {
                    return ` <tr>
                <td>
                  ${r.date}
                </td>
                <td>
                    ${r.carsRented}
                </td>
                <td>
                    ${r.income}
                </td>
            </tr>`;
                }).join('');

                let template = `
  <div class="form-group">
    <label for="exampleInputEmail1">Date Filter</label>
    <input type="date" id="${dateFilterINput}" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
  </div>
<button type="button" id="${filterButtonID}" class="btn btn-primary">Filtrar</button>
<table id="SalesReportTable"
       style="width: 100%;" class="mdl-data-table mdl-js-data-table mdl-data-table mdl-shadow--2dp">
    <thead>
        <tr>
            <th>
                Date
            </th>
            <th>
                Cars Rented
            </th>
            <th>
                Income
            </th>
        </tr>
    </thead>
    <tbody>
        ${rows}
    </tbody>
</table>
`;
                $this.empty();
                $this.append(template);

                $(document.getElementById(filterButtonID)).on('click', function () {
                    let dateVal = document.getElementById(dateFilterINput).value;
                    console.warn('dateval', dateVal)

                    $this.Fetch(dateVal ? new Date(dateVal.split('-')) : undefined);
                });

            }, function (error) {
                alert("An error has occurred, see console for details.");
                console.error('API ERROR', error);
            });
        };

        const TableDOM = this;

        console.log('Table Dom', TableDOM);

        if (!url) throw 'The API URL is required.';

      
        return $this;
    };

})();