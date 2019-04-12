(function () {
    // arguments is expected to be an object with the following structure:
    /*
     {
         url: 'API_URL',
         filters: [
         {
            type:'<date,number,text>',
            name:'field_name'
         }]
    }    
     */
    $.WeRentCar123TableFilter = function ({ url, filters }) {
        const TableDOM = this;
        if (!url) throw 'The API URL is required.';
        if (filters.length > 0) {
            filters.forEach(filter => {

            });
        }
    };

})();