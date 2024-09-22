    import { createSlice, PayloadAction } from '@reduxjs/toolkit';
    
    interface ModalState {
        isModalOpen: boolean;
        modalContent: 'login' | 'register' | 'forgotPassword';
    }
    
    const initialState: ModalState = {
        isModalOpen: false,
        modalContent: 'login',
    };
    
    const modalSlice = createSlice({
        name: 'modal',
        initialState,
        reducers: {
            openModal(state, action: PayloadAction<'login' | 'register' | 'forgotPassword'>) {
                state.isModalOpen = true;
                state.modalContent = action.payload;
            },
            closeModal(state) {
                state.isModalOpen = false;
            },
        },
    });
    
    export const { openModal, closeModal } = modalSlice.actions;
    export default modalSlice.reducer;
