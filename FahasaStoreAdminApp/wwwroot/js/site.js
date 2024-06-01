
$(function () {
    AcctiveSidebar();
    GetUserLogin();
});

const AcctiveSidebar = () => {
    var active = $('#accordionSidebar').attr("active");
    var listNavItem = $('#accordionSidebar li.nav-item');
    listNavItem.map((index, item) => {
        if (index == active) {
            $(item).addClass("active");
            var navLink = $(item).find(".nav-link.collapsed");
            if (navLink.length > 0) {
                var urlCurrent = $('#accordionSidebar').attr("urlCurrent");
                $(navLink).removeClass("collapsed");
                $(item).find(".collapse").addClass("show");
                $(item).find(".collapse-item").filter('[href="' + urlCurrent + '"]').addClass("active");
            }
        }
    });
}

const HandlerCRUD = (e, event) => {
    event.preventDefault();
    var href = $(e).attr("href");
    var id = $(e).attr("IdValue");
    $.ajax({
        url: `${href}/${id}`,
        type: 'GET',
        success: function (data) {
            $('#modal-for-crud').html(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var errorMessage = `Error fetching data: ${jqXHR.status} ${jqXHR.statusText}`;
            if (jqXHR.responseText) {
                errorMessage += `\nResponse: ${jqXHR.responseText}`;
            }
            alert(errorMessage);
        }
    });
}

const GetUserLogin = () => {
    $.ajax({
        url: `/Account/UserLogin`,
        type: 'GET',
        success: function (data) {
            $('#userDropdown span').html(data.fullName);
            $('#userDropdown img').attr('src', data.imageUrl);
        },
        error: function() {
            console.log("Error: user login");
        }
    });
}