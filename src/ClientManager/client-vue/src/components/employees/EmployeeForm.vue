<template>
  <b-container fluid>
    <b-form @submit.prevent="addEmployee">
      <b-form-group id="input-group-1" label="Employee's First Name:" label-for="input-1">
        <b-form-input
          id="input-1"
          v-model="formData.firstName"
          type="text"
          required
          placeholder="Enter first name"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Employee's Last Name:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="formData.lastName"
          type="text"
          required
          placeholder="Enter last name"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-3" label="Employee's Email:" label-for="input-2">
        <b-form-input
          id="input-3"
          v-model="formData.email"
          type="text"
          required
          placeholder="Enter a valid email"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-4" label="Employee's Phone Number:" label-for="input-4">
        <b-form-input
          id="input-4"
          v-model="formData.phoneNumber"
          type="text"
          required
          placeholder="Enter a phone number"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-5" label="Employee's Position:" label-for="input-5">
        <b-form-input
          id="input-5"
          v-model="formData.position"
          type="text"
          placeholder="Enter Position"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-6" label="Salary Rate:" label-for="input-6">
        <b-form-input
          id="input-6"
          v-model="formData.salary"
          type="text"
          placeholder="Enter expected salary rate"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-7" label="Hourly Rate:" label-for="input-7">
        <b-form-input
          id="input-7"
          v-model="formData.hourlyRate"
          type="text"
          placeholder="Enter rate"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-8" label="Employee Start Date:" label-for="input-8">
        <b-form-input
          id="input-8"
          v-model="formData.startDate"
          type="date"
          placeholder="Enter a starting date"
        ></b-form-input>
      </b-form-group>

      <b-col :md="5" offset="4">
        <b-button type="submit" variant="primary">Submit</b-button>
        <b-button :to="{ name: 'Home'}" variant="danger">Cancel</b-button>
      </b-col>
    </b-form>

    <b-modal ref="alertModal" :title="alertModalTitle" :ok-only="true" @ok="onAlertModalOkClick">
      <p class="my-4">{{ alertModalContent }}</p>
    </b-modal>
  </b-container>
</template>

<script>
import EmployeeService from "@/services/employee-service";

export default {
  name: "employee-form",
  data() {
    return {
      formData: {
        firstName: "",
        lastName: "",
        email: "",
        phoneNumber: "",
        position: "",
        salary: "",
        hourlyRate: "",
        startDate: ""
      },
      alertModalTitle: "",
      alertModalContent: "",
      isSuccessful: false
    };
  },
  methods: {
    addEmployee() {
      EmployeeService.create(this.formData)
        .then(() => {
          this.isSuccessful = true;
          this.alertModalTitle = "Success!";
          this.alertModalContent = "Successfully Added Employee";
          this.$refs.alertModal.show();

          this.formData = {
            firstName: "",
            lastName: "",
            email: "",
            phoneNumber: "",
            position: "",
            salary: "",
            hourlyRate: "",
            startDate: ""
          };
        })
        .catch(error => {
          this.isSuccessful = false;
          this.alertModalTitle = "Error";
          this.alertModalContent = error.response.data;
          this.$refs.alertModal.show();
        });
    },
    onAlertModalOkClick() {
      if (this.isSuccessful) {
        this.$router.push({ name: "EmployeeTable" });
      }
    }
  }
};
</script>

<style scoped>
form {
  margin-bottom: 2rem;
  margin-top: 20px;
  min-height: 20px;
  padding: 19px;
  margin-bottom: 20px;
  background-color: #f5f5f5;
  border: 1px solid #e3e3e3;
  border-radius: 4px;
  box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.05);
}

button {
  margin: 1rem;
}
</style>