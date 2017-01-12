(function() {

  (function($, window) {
    var Tour, document;
    document = window.document;
    Tour = (function() {

      function Tour(options) {
        var _this = this;
        this._options = $.extend({
          afterSetState: function(key, value) {},
          afterGetState: function(key, value) {}
        }, options);
        this._steps = [];
        this.setCurrentStep();
        $(document).on("click", ".popover .next", function(e) {
          e.preventDefault();
          return _this.next();
        });
        $(document).on("click", ".popover .end", function(e) {
          e.preventDefault();
          return _this.end();
        });
      }

      Tour.prototype.setState = function(key, value) {
        $.cookie("tour_" + key, value, {
          expires: 36500,
          path: '/'
        });
        return this._options.afterSetState(key, value);
      };

      Tour.prototype.getState = function(key) {
        var value;
        value = $.cookie("tour_" + key);
        this._options.afterGetState(key, value);
        return value;
      };

      Tour.prototype.addStep = function(step) {
        return this._steps.push(step);
      };

      Tour.prototype.getStep = function(i) {
        return $.extend({
          path: "",
          placement: "right",
          title: "",
          content: "",
          next: i + 1,
          end: i === this._steps.length - 1,
          animation: true
        }, this._steps[i]);
      };

      Tour.prototype.start = function(force) {
        if (force == null) {
          force = false;
        }
        if (force || !this.ended()) {
          return this.showStep(this._current);
        }
      };

      Tour.prototype.next = function() {
        this.hideStep(this._current);
        return this.showNextStep();
      };

      Tour.prototype.end = function() {
        this.hideStep(this._current);
        return this.setState("end", "yes");
      };

      Tour.prototype.ended = function() {
        return !!this.getState("end");
      };

      Tour.prototype.restart = function() {
        this.setState("current_step", null);
        this.setState("end", null);
        this.setCurrentStep(0);
        return this.start();
      };

      Tour.prototype.hideStep = function(i) {
        var step;
        step = this.getStep(i);
        if (step.onHide != null) {
          step.onHide(this);
        }
        return $(step.element).popover("hide");
      };

      Tour.prototype.showStep = function(i) {
        var endOnClick, step,
          _this = this;
        step = this.getStep(i);
        if (step.element == null) {
          this.end;
          return;
        }
        this.setCurrentStep(i);
        if (step.path !== "" && document.location.pathname !== step.path && document.location.pathname.replace(/^.*[\\\/]/, '') !== step.path) {
          document.location.href = step.path;
          return;
        }
        if ($(step.element).is(":hidden")) {
          this.showNextStep();
          return;
        }
        endOnClick = step.endOnClick || step.element;
        $(endOnClick).one("click", function() {
          return _this.endCurrentStep();
        });
        if (step.onShow != null) {
          step.onShow(this);
        }
        return this._showPopover(step, i);
      };

      Tour.prototype.setCurrentStep = function(value) {
        if (value != null) {
          this._current = value;
          return this.setState("current_step", value);
        } else {
          this._current = this.getState("current_step");
          if (this._current === null || this._current === "null") {
            return this._current = 0;
          } else {
            return this._current = parseInt(this._current);
          }
        }
      };

      Tour.prototype.endCurrentStep = function() {
        var step;
        this.hideStep(this._current);
        step = this.getStep(this._current);
        return this.setCurrentStep(step.next);
      };

      Tour.prototype.showNextStep = function() {
        var step;
        step = this.getStep(this._current);
        return this.showStep(step.next);
      };

      Tour.prototype._showPopover = function(step, i) {
        var content, tip;
        content = "" + step.content + "<br /><p>";
        if (step.end) {
          content += "<a href='#' class='end'>End</a>";
        } else {
          content += "<a href='#" + step.next + "' class='next'>Next &raquo;</a>          <a href='#' class='pull-right end'>End tour</a></p>";
        }
        $(step.element).popover({
          placement: step.placement,
          trigger: "manual",
          title: step.title,
          content: content,
          animation: step.animation
        }).popover("show");
        tip = $(step.element).data("popover").tip();
        this._reposition(tip);
        return this._scrollIntoView(tip);
      };

      Tour.prototype._reposition = function(tip) {
        var offsetBottom, offsetRight, tipOffset;
        tipOffset = tip.offset();
        offsetBottom = $(document).outerHeight() - tipOffset.top - $(tip).outerHeight();
        if (offsetBottom < 0) {
          tipOffset.top = tipOffset.top + offsetBottom;
        }
        offsetRight = $(document).outerWidth() - tipOffset.left - $(tip).outerWidth();
        if (offsetRight < 0) {
          tipOffset.left = tipOffset.left + offsetRight;
        }
        if (tipOffset.top < 0) {
          tipOffset.top = 0;
        }
        if (tipOffset.left < 0) {
          tipOffset.left = 0;
        }
        return tip.offset(tipOffset);
      };

      Tour.prototype._scrollIntoView = function(tip) {
        var tipRect;
        tipRect = tip.get(0).getBoundingClientRect();
        if (!(tipRect.top > 0 && tipRect.bottom < $(window).height() && tipRect.left > 0 && tipRect.right < $(window).width())) {
          return tip.get(0).scrollIntoView(true);
        }
      };

      return Tour;

    })();
    return window.Tour = Tour;
  })(jQuery, window);

}).call(this);
