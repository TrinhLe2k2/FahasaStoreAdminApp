
$(function () {
    Start();
});

const Start = () => {
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
        error: function () {
            console.error('Error fetching');
        }
    });
}
