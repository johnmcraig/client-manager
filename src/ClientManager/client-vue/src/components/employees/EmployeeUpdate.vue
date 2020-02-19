<template>
  <b-container fluid style="margin-top: 25px;">
    <b-row>
      <b-col md="6">
        <router-link
          :to="{ name: 'EmployeeTable' } "
          class="btn btn-primary ml-2 mb-2"
        >Back to Table</router-link>
      </b-col>
    </b-row>

    <b-row>
      <b-col md="12">
        <b-form @submit.prevent="updateEmployee">
          <b-form-group id="input-group-1" label="Employee's First Name:" label-for="input-1">
            <b-form-input
              id="input-1"
              v-model="formData.firstName"
              type="text"
              required
              placeholder="Enter name"
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

          <b-form-group id="input-group-3" label="Employee Email:" label-for="input-3">
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
              type="text"
              placeholder="Enter a starting date"
            ></b-form-input>
          </b-form-group>

          <b-form-group id="input-group-9" label="Employee End Date:" label-for="input-9">
            <b-form-input
              id="input-9"
              v-model="formData.endDate"
              type="text"
              placeholder="Enter ending date"
            ></b-form-input>
          </b-form-group>

          <b-col :md="5" offset="4">
            <b-button type="submit" variant="primary">Save</b-button>
            <b-button :to="{ name: 'EmployeeTable'}" variant="danger">Cancel</b-button>
          </b-col>
        </b-form>
      </b-col>
    </b-row>

    <b-modal ref="alertModal" :title="alertModalTitle" :ok-only="true" @ok="onAlertModalOkClick">
      <p class="my-4">{{ alertModalContent }}</p>
    </b-modal>
  </b-container>
</template>

<script>
import EmployeeService from "@/services/employee-service";

export default {
  name: "EmployeeUpdate",
  data() {
    return {
      formData: {
        fisrtName: "",
        lastName: "",
        email: "",
        phoneNumber: "",
        position: "",
        salary: "",
        hourlyRate: "",
        startDate: "",
        endDate: ""
      },
      alertModalTitle: "",
      alertModalContent: "",
      isSuccessfull: false
    };
  },
  created() {
    EmployeeService.getSingle(this.$router.currentRoute.params.id).then(
      response => {
        this.formData.firstName = response.data.firstName;
        this.formData.lastName = response.data.lastName;
        this.formData.email = response.data.email;
        this.formData.phoneNumber = response.data.phoneNumber;
        this.formData.position = response.data.position;
        this.formData.salary = response.data.salary;
        this.formData.hourlyRate = response.data.hourlyRate;
        this.formData.startDate = response.data.startDate;
        this.formData.endDate = response.data.endDate;
      }
    );
  },
  methods: {
    updateEmployee() {
      EmployeeService.update(this.$router.currentRoute.params.id, this.formData)
        .then(() => {
          this.isSuccessfull = true;
          this.alertModalTitle = "Success!";
          this.alertModalContent = "Successfully Updated Employee";
          this.$refs.alertModal.show();
        })
        .catch(error => {
          this.isSuccessfull = false;
          this.alertModalTitle = "Error";
          this.alertModalContent = error.response.data;
          this.$refs.alertModal.show();
        });
    },
    onAlertModalOkClick() {
      if (this.isSuccessfull) {
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
