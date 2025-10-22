// Identity Server - Interactive JavaScript

// Global app object
const IdentityServer = {
    // Initialize all components
    init: function() {
        this.initDropdowns();
        this.initModals();
        this.initPasswordToggles();
        this.initPasswordStrength();
        this.initCopyButtons();
        this.initFormValidation();
        this.initTooltips();
        this.initTabs();
        this.initSidebar();
        this.initConfirmDialogs();
    },

    // Dropdown functionality
    initDropdowns: function() {
        document.addEventListener('click', function(e) {
            const trigger = e.target.closest('[data-dropdown-trigger]');

            if (trigger) {
                e.preventDefault();
                const targetId = trigger.getAttribute('data-dropdown-trigger');
                const dropdown = document.getElementById(targetId);

                if (dropdown) {
                    dropdown.classList.toggle('hidden');
                }

                // Close other dropdowns
                document.querySelectorAll('[data-dropdown]').forEach(function(dd) {
                    if (dd.id !== targetId) {
                        dd.classList.add('hidden');
                    }
                });
            } else {
                // Close all dropdowns when clicking outside
                if (!e.target.closest('[data-dropdown]')) {
                    document.querySelectorAll('[data-dropdown]').forEach(function(dd) {
                        dd.classList.add('hidden');
                    });
                }
            }
        });
    },

    // Modal functionality
    initModals: function() {
        // Open modal
        document.addEventListener('click', function(e) {
            const trigger = e.target.closest('[data-modal-trigger]');
            if (trigger) {
                e.preventDefault();
                const targetId = trigger.getAttribute('data-modal-trigger');
                const modal = document.getElementById(targetId);
                if (modal) {
                    modal.classList.remove('hidden');
                    document.body.style.overflow = 'hidden';
                }
            }
        });

        // Close modal
        document.addEventListener('click', function(e) {
            const closeBtn = e.target.closest('[data-modal-close]');
            if (closeBtn) {
                e.preventDefault();
                const modal = closeBtn.closest('[data-modal]');
                if (modal) {
                    modal.classList.add('hidden');
                    document.body.style.overflow = '';
                }
            }

            // Close on backdrop click
            if (e.target.hasAttribute('data-modal')) {
                e.target.classList.add('hidden');
                document.body.style.overflow = '';
            }
        });

        // Close modal on escape key
        document.addEventListener('keydown', function(e) {
            if (e.key === 'Escape') {
                document.querySelectorAll('[data-modal]').forEach(function(modal) {
                    if (!modal.classList.contains('hidden')) {
                        modal.classList.add('hidden');
                        document.body.style.overflow = '';
                    }
                });
            }
        });
    },

    // Password toggle visibility
    initPasswordToggles: function() {
        document.addEventListener('click', function(e) {
            const toggle = e.target.closest('[data-password-toggle]');
            if (toggle) {
                e.preventDefault();
                const targetId = toggle.getAttribute('data-password-toggle');
                const input = document.getElementById(targetId);

                if (input) {
                    if (input.type === 'password') {
                        input.type = 'text';
                        toggle.innerHTML = '<svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.878 9.878l4.242 4.242M9.88 9.88l-3.29-3.29m7.532 7.532l3.29 3.29M3 3l3.59 3.59m0 0A9.953 9.953 0 0112 5c4.478 0 8.268 2.943 9.543 7a10.025 10.025 0 01-4.132 5.411m0 0L21 21"></path></svg>';
                    } else {
                        input.type = 'password';
                        toggle.innerHTML = '<svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"></path><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"></path></svg>';
                    }
                }
            }
        });
    },

    // Password strength meter
    initPasswordStrength: function() {
        document.addEventListener('input', function(e) {
            if (e.target.hasAttribute('data-password-strength')) {
                const password = e.target.value;
                const meterId = e.target.getAttribute('data-password-strength');
                const meter = document.getElementById(meterId);

                if (meter) {
                    const strength = IdentityServer.calculatePasswordStrength(password);
                    meter.className = 'password-strength-meter mt-2';

                    if (strength.score === 0) {
                        meter.classList.add('hidden');
                    } else {
                        meter.classList.remove('hidden');
                        if (strength.score <= 2) {
                            meter.classList.add('password-strength-weak');
                        } else if (strength.score <= 3) {
                            meter.classList.add('password-strength-medium');
                        } else {
                            meter.classList.add('password-strength-strong');
                        }
                    }
                }
            }
        });
    },

    calculatePasswordStrength: function(password) {
        let score = 0;
        if (!password) return { score: 0 };

        // Length
        if (password.length >= 8) score++;
        if (password.length >= 12) score++;

        // Has lowercase
        if (/[a-z]/.test(password)) score++;

        // Has uppercase
        if (/[A-Z]/.test(password)) score++;

        // Has number
        if (/\d/.test(password)) score++;

        // Has special character
        if (/[^A-Za-z0-9]/.test(password)) score++;

        return { score: Math.min(score, 5) };
    },

    // Copy to clipboard
    initCopyButtons: function() {
        document.addEventListener('click', function(e) {
            const copyBtn = e.target.closest('[data-copy]');
            if (copyBtn) {
                e.preventDefault();
                const text = copyBtn.getAttribute('data-copy');

                navigator.clipboard.writeText(text).then(function() {
                    IdentityServer.showToast('Copied to clipboard', 'success');

                    // Visual feedback
                    const originalText = copyBtn.innerHTML;
                    copyBtn.innerHTML = '<svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 13l4 4L19 7"></path></svg>';
                    setTimeout(function() {
                        copyBtn.innerHTML = originalText;
                    }, 2000);
                });
            }
        });
    },

    // Form validation
    initFormValidation: function() {
        document.querySelectorAll('form[data-validate]').forEach(function(form) {
            form.addEventListener('submit', function(e) {
                let isValid = true;

                form.querySelectorAll('[required]').forEach(function(input) {
                    if (!input.value.trim()) {
                        isValid = false;
                        input.classList.add('border-red-500');

                        // Show error message
                        let errorMsg = input.parentElement.querySelector('.error-message');
                        if (!errorMsg) {
                            errorMsg = document.createElement('p');
                            errorMsg.className = 'error-message text-xs text-red-600 mt-1';
                            errorMsg.textContent = 'This field is required';
                            input.parentElement.appendChild(errorMsg);
                        }
                    } else {
                        input.classList.remove('border-red-500');
                        const errorMsg = input.parentElement.querySelector('.error-message');
                        if (errorMsg) errorMsg.remove();
                    }
                });

                if (!isValid) {
                    e.preventDefault();
                    IdentityServer.showToast('Please fill in all required fields', 'error');
                }
            });
        });
    },

    // Tooltips
    initTooltips: function() {
        document.querySelectorAll('[data-tooltip]').forEach(function(element) {
            element.addEventListener('mouseenter', function() {
                const text = this.getAttribute('data-tooltip');
                const tooltip = document.createElement('div');
                tooltip.className = 'fixed bg-gray-900 text-white text-xs py-1 px-2 rounded shadow-lg z-50';
                tooltip.textContent = text;
                tooltip.id = 'tooltip-' + Math.random().toString(36).substr(2, 9);

                document.body.appendChild(tooltip);

                const rect = this.getBoundingClientRect();
                tooltip.style.top = (rect.top - tooltip.offsetHeight - 5) + 'px';
                tooltip.style.left = (rect.left + (rect.width / 2) - (tooltip.offsetWidth / 2)) + 'px';

                this.tooltipId = tooltip.id;
            });

            element.addEventListener('mouseleave', function() {
                const tooltip = document.getElementById(this.tooltipId);
                if (tooltip) tooltip.remove();
            });
        });
    },

    // Tabs
    initTabs: function() {
        document.addEventListener('click', function(e) {
            const tab = e.target.closest('[data-tab]');
            if (tab) {
                e.preventDefault();
                const targetId = tab.getAttribute('data-tab');
                const tabGroup = tab.closest('[data-tab-group]');

                if (tabGroup) {
                    // Remove active class from all tabs in group
                    tabGroup.querySelectorAll('[data-tab]').forEach(function(t) {
                        t.classList.remove('border-blue-600', 'text-blue-600');
                        t.classList.add('border-transparent', 'text-gray-600');
                    });

                    // Add active class to clicked tab
                    tab.classList.remove('border-transparent', 'text-gray-600');
                    tab.classList.add('border-blue-600', 'text-blue-600');

                    // Hide all tab contents
                    document.querySelectorAll('[data-tab-content]').forEach(function(content) {
                        content.classList.add('hidden');
                    });

                    // Show target tab content
                    const target = document.getElementById(targetId);
                    if (target) {
                        target.classList.remove('hidden');
                    }
                }
            }
        });
    },

    // Sidebar toggle for mobile
    initSidebar: function() {
        const sidebarToggle = document.getElementById('sidebar-toggle');
        const sidebar = document.getElementById('sidebar');
        const sidebarOverlay = document.getElementById('sidebar-overlay');

        if (sidebarToggle && sidebar) {
            sidebarToggle.addEventListener('click', function() {
                sidebar.classList.toggle('-translate-x-full');
                if (sidebarOverlay) {
                    sidebarOverlay.classList.toggle('hidden');
                }
            });
        }

        if (sidebarOverlay) {
            sidebarOverlay.addEventListener('click', function() {
                sidebar.classList.add('-translate-x-full');
                sidebarOverlay.classList.add('hidden');
            });
        }
    },

    // Confirm dialogs
    initConfirmDialogs: function() {
        document.addEventListener('click', function(e) {
            const confirmBtn = e.target.closest('[data-confirm]');
            if (confirmBtn) {
                const message = confirmBtn.getAttribute('data-confirm');
                if (!confirm(message)) {
                    e.preventDefault();
                    e.stopPropagation();
                    return false;
                }
            }
        });
    },

    // Toast notifications
    showToast: function(message, type = 'info') {
        const toastContainer = document.getElementById('toast-container') || this.createToastContainer();

        const toast = document.createElement('div');
        toast.className = 'toast-enter bg-white rounded-lg shadow-lg p-4 mb-3 flex items-start max-w-sm';

        const iconColors = {
            success: 'text-green-500',
            error: 'text-red-500',
            warning: 'text-yellow-500',
            info: 'text-blue-500'
        };

        const icons = {
            success: '<path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 13l4 4L19 7"></path>',
            error: '<path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"></path>',
            warning: '<path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"></path>',
            info: '<path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>'
        };

        toast.innerHTML = `
            <div class="flex-shrink-0">
                <svg class="w-6 h-6 ${iconColors[type] || iconColors.info}" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    ${icons[type] || icons.info}
                </svg>
            </div>
            <div class="ml-3 flex-1">
                <p class="text-sm font-medium text-gray-900">${message}</p>
            </div>
            <button class="ml-4 flex-shrink-0 text-gray-400 hover:text-gray-500" onclick="this.parentElement.remove()">
                <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12"></path>
                </svg>
            </button>
        `;

        toastContainer.appendChild(toast);

        // Auto-dismiss after 5 seconds
        setTimeout(function() {
            toast.style.opacity = '0';
            setTimeout(function() {
                toast.remove();
            }, 300);
        }, 5000);
    },

    createToastContainer: function() {
        const container = document.createElement('div');
        container.id = 'toast-container';
        container.className = 'fixed top-4 right-4 z-50';
        document.body.appendChild(container);
        return container;
    }
};

// Initialize on DOM ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', function() {
        IdentityServer.init();
    });
} else {
    IdentityServer.init();
}
