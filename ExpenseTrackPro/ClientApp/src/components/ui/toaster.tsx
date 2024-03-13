"use client";

import {
  Toast,
  ToastClose,
  ToastDescription,
  ToastProvider,
  ToastTitle,
  ToastViewport,
} from "@/components/ui/toast";
import { useToast } from "@/components/ui/use-toast";

export function Toaster() {
  const { toasts } = useToast();

  return (
    <ToastProvider>
      {toasts.map(function ({
        id,
        title,
        description,
        action,
        toastContainerStyles,
        toastTitleStyles,
        toastDescriptionStyles,
        toastCloseStyles,
        ...props
      }) {
        return (
          <Toast key={id} {...props} className={toastContainerStyles}>
            {title && (
              <ToastTitle className={toastTitleStyles}>{title}</ToastTitle>
            )}
            {description && (
              <ToastDescription className={toastDescriptionStyles}>
                {description}
              </ToastDescription>
            )}

            {action}

            <ToastClose className={toastCloseStyles} />
          </Toast>
        );
      })}
      <ToastViewport />
    </ToastProvider>
  );
}
