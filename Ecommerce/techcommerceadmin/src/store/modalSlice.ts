import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface ModalState {
  isOpen: boolean;
  modalContent: 'forgotPassword' | 'login' | null; // Ограничиваем контент модалки
}

const initialState: ModalState = {
  isOpen: false,
  modalContent: null,
};

const modalSlice = createSlice({
  name: 'modal',
  initialState,
  reducers: {
    openModal(state, action: PayloadAction<'forgotPassword' | 'login'>) { 
      state.isOpen = true;
      state.modalContent = action.payload;
    },
    closeModal(state) {
      state.isOpen = false;
      state.modalContent = null;
    },
  },
});

export const { openModal, closeModal } = modalSlice.actions;
export default modalSlice.reducer;
